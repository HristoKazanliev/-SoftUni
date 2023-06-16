using Forum.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services
{
	public interface IPostService
	{
		Task<IEnumerable<PostViewModel>> ListAllAsync();

        Task AddPostAsync(PostFormModel postViewModel);

        Task<PostFormModel> GetForEditOrDeleteByIdAsync(string id);

        Task EditByIdAsync(string id, PostFormModel postEditedModel);

        Task DeleteByIdAsync(string id);
    }
}
