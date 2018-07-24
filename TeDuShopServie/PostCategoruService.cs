using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeDuShopData.Infrrastructure;
using TeDuShopData.Repositories;
using TeduSopModel.Model;

namespace TeDuShopServie
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParent(int parentId);
        PostCategory GetById(int Id);

    }
    public class PostCategoruService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;
        public PostCategoruService(IPostCategoryRepository postCategoryRepository,IUnitOfWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {

            _postCategoryRepository.Add(postCategory);

        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParent(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int Id)
        {
            return _postCategoryRepository.GetSingleById(Id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
                }
    }
}
