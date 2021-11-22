using NLayerProject.Core.Repositories;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository products { get; }

        ICategoryRepository categories { get; }

        Task CommitAsync();

        void Commit();
    }
}

// There are multiple data entities in an application that we need
// to maintain the data in most situations. They have some general
// functionalities that all entities should have (CRUD). Therefore, we will
// need a generic repository that can be applied to all entities in a given
// project rather than writing code for each entity that might cause code
// duplication problems. With a generic repository, we write one base class
// that handles all CRUD operations and inherit to write more entity-specific
// operations when necessary.