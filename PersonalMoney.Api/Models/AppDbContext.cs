using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services;

namespace PersonalMoney.Api.Models
{
    /// <summary>
    /// Application database context
    /// </summary>
    /// <seealso cref="DbContext" />
    public class AppDbContext : DbContext
    {
        private readonly UserResolverService userResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext" /> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        /// <param name="userResolver">The user resolver.</param>
        public AppDbContext(DbContextOptions options, UserResolverService userResolver)
            : base(options)
        {
            this.userResolver = userResolver;
        }

        /// <summary>
        /// Gets or sets the account types.
        /// </summary>
        /// <value>
        /// The account types.
        /// </value>
        public DbSet<AccountType> AccountTypes { get; set; }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the payees.
        /// </summary>
        /// <value>
        /// The payees.
        /// </value>
        public DbSet<Payee> Payees { get; set; }

        /// <summary>
        /// Gets or sets the sub categories.
        /// </summary>
        /// <value>
        /// The sub categories.
        /// </value>
        public DbSet<SubCategory> SubCategories { get; set; }

        /// <summary>
        /// Gets or sets the sub transactions.
        /// </summary>
        /// <value>
        /// The sub transactions.
        /// </value>
        public DbSet<SubTransaction> SubTransactions { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the transaction tags.
        /// </summary>
        /// <value>
        /// The transaction tags.
        /// </value>
        public DbSet<TransactionTag> TransactionTags { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(c => c.Transactions)
                .WithOne(c => c.Account);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.ToTransactions)
                .WithOne(c => c.ToAccount);

            base.OnModelCreating(modelBuilder);
        }

        #region SaveChanges

        /// <inheritdoc />
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTimeTracking();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <inheritdoc />
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTimeTracking();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddTimeTracking()
        {
            if (!ChangeTracker.HasChanges())
            {
                return;
            }

            int? userId = 0;
            if (userResolver != null)
            {
                string id = userResolver.GetUserId();
                userId = Users.FirstOrDefault(c => c.UserId == id)?.Id;
            }

            IEnumerable<EntityEntry<TimeModel>> shortEntries = ChangeTracker.Entries<TimeModel>();
            AddUserAndTime(shortEntries, userId);
        }

        private static void AddUserAndTime(IEnumerable<EntityEntry<TimeModel>> entries, int? id)
        {
            foreach (EntityEntry<TimeModel> item in entries.Where(c => c.State != EntityState.Unchanged))
            {
                var currentTime = DateTime.UtcNow;
                item.Entity.UpdatedTime = currentTime;

                if (id.HasValue)
                {
                    item.Entity.UserId = id.Value;
                }

                if (item.Entity.Id == 0)
                {
                    item.Entity.CreatedTime = currentTime;
                }
            }
        }

        #endregion SaveChanges
    }
}