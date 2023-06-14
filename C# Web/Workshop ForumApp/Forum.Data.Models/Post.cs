using System.ComponentModel.DataAnnotations;
using static Forum.Common.EntityValidationConstants.Post;

namespace Forum.Data.Models
{
	public class Post
	{
		public Post()
		{
			this.Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }
		//init setters only for properties, which won't be changed after the initialization. For example,
		//the Id property will always be the same

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = null!;
	}
}
