using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext() : base("CypherMVC")
        {
            Database.SetInitializer<FeedbackContext>(new FeedbackInitializer());
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<MessageThread> Threads { get; set; }

    }

    public class FeedbackInitializer : DropCreateDatabaseIfModelChanges<FeedbackContext>
    {
        protected override void Seed(FeedbackContext context)
        {
            //Add the admins
            var admins = new List<Admin>() {
                new Admin() { Username = "Bob" },
                new Admin() { Username = "Joe" },
                new Admin() { Username = "Jane" },
                new Admin() { Username = "Sarah" }
            };
            foreach (var admin in admins)
            {
                context.Admins.Add(admin);
            }
            context.SaveChanges();

            //Add some threads
            context.Threads.Add(new MessageThread() { MessageThreadId = 1 });
            context.Threads.Add(new MessageThread() { MessageThreadId = 2 });
            context.Threads.Add(new MessageThread() { MessageThreadId = 3 });
            context.Threads.Add(new MessageThread() { MessageThreadId = 4 });
            context.Threads.Add(new MessageThread() { MessageThreadId = 5 });
            context.Threads.Add(new MessageThread() { MessageThreadId = 6 });
            context.Threads.Add(new MessageThread() { MessageThreadId = 7 });

            context.SaveChanges();

            //Add some messages
            var messages = new List<Message>()
            {
                new Message() { MessageThreadId = 1, Subject = "Concerned Customer",  Created = DateTime.Now, Author = "mark@sample.com", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla consequat neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Message() { MessageThreadId = 2, Subject = "Question about shipping",  Created = DateTime.Now, Author = "joe@sample.com", Content = "Nulla consequat neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Message() { MessageThreadId = 3, Subject = "Mobile app troubles", Created = DateTime.Now, Author = "sam@sample.com", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla consequat neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Message() { MessageThreadId = 4, Subject = "Poor service", Created = DateTime.Now, Author = "alex@sample.com", Content = "Consequat neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Message() { MessageThreadId = 5, Subject = "Like the new site!", Created = DateTime.Now, Author = "john@sample.com", Content = "Adipiscing elit. Nulla consequat neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Message() { MessageThreadId = 6, Subject = "Mailing question",  Created = DateTime.Now, Author = "emma@sample.com", Content = "Neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new Message() { MessageThreadId = 7, Subject = "Question about policies",  Created = DateTime.Now, Author = "hannah@sample.com", Content = "Dolor sit amet, consectetur adipiscing elit. Nulla consequat neque sed massa sagittis, sed varius lorem faucibus. Nunc nec lacus sed magna vehicula interdum. Aliquam orci erat, rutrum vel scelerisque ultrices, venenatis vitae leo. Sed sed sagittis felis, in iaculis risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
            };
            foreach(var message in messages)
            {
                context.Messages.Add(message);
            }
            context.SaveChanges();

            //Add some votes
            var votes = new List<Vote>()
            {
                new Vote() { AdminId = 1 },
                new Vote() { AdminId = 1 },
                new Vote() { AdminId = 2 },
                new Vote() { AdminId = 3 },
                new Vote() { AdminId = 3 },
                new Vote() { AdminId = 4 }
            };
            foreach(var vote in votes)
            {
                context.Votes.Add(vote);
            }
            context.SaveChanges();

            //Add some categories
            var categories = new List<Category>()
            {
                new Category() { Name = "UX", Description = "Problem with user interface or experience" },
                new Category() { Name = "Vendor", Description = "A vendor is unhappy" },
                new Category() { Name = "Personal Complaint", Description = "A bad experience with company personel" }
            };
            foreach(var cat in categories)
            {
                context.Categories.Add(cat);
            }
            context.SaveChanges();

            //Add some tasks
            var tasks = new List<Task>()
            {
                new Task()
                {
                    Title = "Follow up with marketing about materials",
                    Description = "A vendor has not received shipments for an order they placed through the online form.",
                    AssociatedMessageId = 1,
                    AssignedToId = 1,
                    DueDate = DateTime.Now.AddDays(7),
                    CategoryId = 1,
                    Created = DateTime.Now
                },
                new Task()
                {
                    Title = "Vendor issues",
                    Description = "A vendor has not received their order, please address this and check that the order was placed.",
                    AssociatedMessageId = 2,
                    AssignedToId = 2,
                    DueDate = DateTime.Now.AddDays(7),
                    CategoryId = 2,
                    Created = DateTime.Now
                },
                new Task()
                {
                    Title = "Poor customer relations",
                    Description = "Multiple customer complaints have come through about our phone service - please contact customer relations to verify that procedures are being followed.",
                    AssociatedMessageId = 3,
                    AssignedToId = 3,
                    DueDate = DateTime.Now.AddDays(7),
                    CategoryId = 3,
                    Created = DateTime.Now
                }
            };
            foreach(var task in tasks)
            {
                context.Tasks.Add(task);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}