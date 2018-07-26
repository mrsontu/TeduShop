using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopData.Infrrastructure;
using TeDuShopData.Infrrastructure;
using TeDuShopData.Repositories;
using TeduSopModel.Model;

namespace TeduShopUnitTest.RepositoryTest
{
    [TestClass]
    class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository postCategoryRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            postCategoryRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "Test-Category";
            postCategory.Alias = "Test-Category";
            postCategory.Status = true;
            var result = postCategoryRepository.Add(postCategory);
            unitOfWork.Commit();
            Assert.AreEqual(1, result.ID);

        }
    }
}
