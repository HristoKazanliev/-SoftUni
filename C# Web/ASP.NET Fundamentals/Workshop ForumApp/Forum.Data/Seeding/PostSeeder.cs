using Forum.Data.Models;

namespace Forum.Data.Seeding
{
	internal class PostSeeder
	{
		internal Post[] GeneratePosts()
		{
			ICollection<Post> posts = new HashSet<Post>();
			Post currentPost;

			currentPost = new Post()
			{
				Id = Guid.NewGuid(),
				Title = "My First Post",
				Content = "My first post will be about performing " + "CRUD operations in MVC. It's so much fun!"
			};
			posts.Add(currentPost);
			currentPost = new Post()
			{
				Id = Guid.NewGuid(),
				Title = "My Second Post",
				Content = "This is my second post. " + "CRUD operations in mVC are getting more and more interesting!"
			};
			posts.Add(currentPost);
			currentPost = new Post()
			{
				Id = Guid.NewGuid(),
				Title = "My third Post",
				Content = "Hello there! I'm getting better and better with the " + "CRUD operations in MVC. Stay tuned!"
			};
			posts.Add(currentPost);

			return posts.ToArray();

		}
	}
}
