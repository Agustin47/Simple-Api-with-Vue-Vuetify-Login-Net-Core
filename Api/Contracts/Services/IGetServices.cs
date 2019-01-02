
namespace Contracts.Services
{
    using Contracts.RequestResponseContracts;

    public interface IGetServices
    {
        /// <summary>
        /// Obtiene los usuarios por nombre o id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetClientResponse GetClient(GetClientRequest request);

        /// <summary>
        /// Obtiene las policies de un usuario.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetClientPoliciesResponse GetClientPolicies(GetClientPoliciesRequest request);

        /// <summary>
        /// Obtiene los usuarios que tengan dicha policie.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetClientByPoliciesResponse GetUserByPolicies(GetClientByPoliciesRequest request);

    }
}
