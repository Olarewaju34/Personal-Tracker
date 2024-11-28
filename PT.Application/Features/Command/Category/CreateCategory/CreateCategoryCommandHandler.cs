using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.Category.CreateCategory
{
    public class CreateCategoryCommandHandler(IUserContext userContext,IUserRepository userRepository,IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : ICommandHandler<CreateCategoryCommand, Result>
    {
        
        public async Task<Result<Result>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(userContext.UserId);
            if (user == null) 
            {
                return Result.Failure(UserErrors.NotFound);
            }
            try
            {
                var category = Categories.CreateCategory(user.Id,request.Name,request.MoneyFlow);
                await categoryRepository.CreateAsync(category);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success(category);
            }
            catch (Exception)
            {

                return Result.Failure(CategoryErrors.Null);
            }

        }
    }
}
