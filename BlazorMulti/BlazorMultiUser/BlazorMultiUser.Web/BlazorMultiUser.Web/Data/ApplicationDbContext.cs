using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorMultiUser.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public required DbSet<Group> Groups { get; set; }
    public required DbSet<TaskToDo> TasksToDo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Group>()
            .HasOne(g => g.Owner)
            .WithMany(u => u.OwnedGroups)
            .HasForeignKey(g => g.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.Assignees)
            .WithMany(a => a.AssignedGroups)
            .UsingEntity<Dictionary<string, object>>(
                "GroupAssignees",
                j => j
                    .HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Group>()
                    .WithMany()
                    .HasForeignKey("GroupId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        modelBuilder.Entity<TaskToDo>()
            .HasOne(t => t.Owner)
            .WithMany(u => u.OwnedTasks)
            .HasForeignKey(t => t.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TaskToDo>()
            .HasMany(t => t.Assignees)
            .WithMany(a => a.AssignedTasks)
            .UsingEntity<Dictionary<string, object>>(
                "TaskAssignees",
                j => j
                    .HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<TaskToDo>()
                    .WithMany()
                    .HasForeignKey("TaskId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        modelBuilder.Entity<TaskToDo>()
            .HasMany(t => t.Groups)
            .WithMany(g => g.Tasks)
            .UsingEntity<Dictionary<string, object>>(
                "TaskGroups",
                j => j
                    .HasOne<Group>()
                    .WithMany()
                    .HasForeignKey("GroupId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<TaskToDo>()
                    .WithMany()
                    .HasForeignKey("TaskId")
                    .OnDelete(DeleteBehavior.Restrict)
            );
    }
}