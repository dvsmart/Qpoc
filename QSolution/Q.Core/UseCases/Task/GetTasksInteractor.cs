

namespace Q.Core.UseCases.Task
{
    using Q.Core.Contracts;
    using Q.Core.shared;
    using System.Collections.Generic;

    public class GetTasksInteractor : IInputBoundary<TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IOutputConverter _outputConverter;
        private readonly IOutputBoundary<List<TaskDto>> _outputBoundary;
        public GetTasksInteractor(ITaskRepository taskRepository, IOutputBoundary<List<TaskDto>> outputBoundary, IOutputConverter outputConverter)
        {
            _taskRepository = taskRepository;
            _outputConverter = outputConverter;
            _outputBoundary = outputBoundary;
        }

        public GetTasksInteractor()
        {

        }

        public async System.Threading.Tasks.Task Process(TaskDto input)
        {
            var tasks = await _taskRepository.GetTasks();

            var output = _outputConverter.Map<List<TaskDto>>(tasks);
            _outputBoundary.Populate(output);
        }
        
    }
}
