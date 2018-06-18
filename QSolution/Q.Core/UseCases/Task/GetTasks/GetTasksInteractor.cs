

namespace Q.Core.UseCases.Task.GetTasks
{
    using Q.Core.Interfaces;
    using Q.Core.shared;
    using System.Collections.Generic;

    public class GetTasksInteractor : IInputBoundary<TaskInput>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IOutputConverter _outputConverter;
        private readonly IOutputBoundary<List<TaskOutput>> _outputBoundary;
        public GetTasksInteractor(ITaskRepository taskRepository, IOutputBoundary<List<TaskOutput>> outputBoundary, IOutputConverter outputConverter)
        {
            _taskRepository = taskRepository;
            _outputConverter = outputConverter;
            _outputBoundary = outputBoundary;
        }

        public GetTasksInteractor()
        {

        }

        public async System.Threading.Tasks.Task Process(TaskInput input)
        {
            var tasks = await _taskRepository.GetTasks();

            var output = _outputConverter.Map<List<TaskOutput>>(tasks);
            _outputBoundary.Populate(output);
        }
        
    }
}
