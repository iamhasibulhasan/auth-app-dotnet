using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;

namespace AuthAppDotNet.Application.ServiceInterfaces.Authentication;

public interface IApplicationUserService
{
    #region Commands
    Task<Result> Create(ApplicationUserCreateDto model, CancellationToken cancellationToken, bool saveChanges = true);
    Task<Result> Update(ApplicationUserCreateDto model, CancellationToken cancellationToken, bool saveChanges = true);
    Task<Result> ModifyStatus(int id, int statusId, CancellationToken cancellationToken, bool saveChanges = true);

    #endregion

    #region Queries
    Task<Result> GetAll(int page, int size, int statusId, CancellationToken cancellationToken);
    Task<Result> GetById(int id, CancellationToken cancellationToken);
    #endregion
}
