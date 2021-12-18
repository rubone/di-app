using DependencyInjectionApp.Interfaces;

namespace DependencyInjectionApp.Services
{
    public class OperationService
    {
        public IOperationTransient OperationTransient { get; }

        public IOperationScoped OperationScoped { get;  }

        public IOperationSingleton OperationSingleton { get;  }

        public IOperationSingletonInstance OperationSingletonInstance { get;  }

        public OperationService(IOperationTransient operationTransient, IOperationScoped operationScoped, IOperationSingleton operationSingleton, IOperationSingletonInstance operationSingletonInstance)
        {
            OperationTransient = operationTransient;
            OperationScoped = operationScoped;
            OperationSingleton = operationSingleton;
            OperationSingletonInstance = operationSingletonInstance;
        }
    }
}
