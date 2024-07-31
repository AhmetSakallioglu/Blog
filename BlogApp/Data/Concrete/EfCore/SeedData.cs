using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange
                        (
                            new Tag { Text = "Web Programlama" },
                            new Tag { Text = "Full Stack" },
                            new Tag { Text = "Game" },
                            new Tag { Text = "Frontend" },
                            new Tag { Text = "Backend" }
                        );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange
                        (
                            new Post
                            {
                                Title = "Asp.Net Core",
                                Content = "Asp.Net Core güzel bir kütüphanedir.",
                                isActive = true,
                                PublishedOn = DateTime.Now.AddDays(-10),
                                Tags = context.Tags.Take(3).ToList(),
                                UserId = 1
                            },
                            new Post
                            {
                                Title = "Unity Oyun Geliştirme",
                                Content = "Unity ile 2D ve 3D oyunlar geliştirebilirsiniz",
                                isActive = true,
                                PublishedOn = DateTime.Now.AddDays(-15),
                                Tags = context.Tags.Take(2).ToList(),
                                UserId = 2
                            },
                            new Post
                            {
                                Title = "Full Stack Developer Olmak",
                                Content = "FullStack developer olmak güzeldir.",
                                isActive = true,
                                PublishedOn = DateTime.Now.AddDays(-8),
                                Tags = context.Tags.Take(4).ToList(),
                                UserId = 1
                            }
                        );
                    context.SaveChanges();
                }
            }
        }

    }
}
