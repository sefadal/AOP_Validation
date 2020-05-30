using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //[ValidationAspect(typeof(ProductValidator), Prioty = 2)]
        [ValidationAspect(typeof(ProductValidator), Prioty = 1)]
        public IResult Add(Product product)
        {
            //ProductValidator productValidator = new ProductValidator();

            //var result = productValidator.Validate(product);

            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //} 1.yol

            //ValidationTool.Validate(new ProductValidator, product); 2.yol

            //Business codes,validation



            _productDal.Add(product);

            return new SuccessResult(message: Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccessResult(message: Messages.ProductDeleted);
        }

        public IDataResult<Product> GetbyId(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult(message: Messages.ProductUpdated);
        }
    }
}
