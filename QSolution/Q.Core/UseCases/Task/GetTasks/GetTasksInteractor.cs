

namespace Q.Core.UseCases.Task.GetTasks
{
    using Q.Core.Interfaces;
    using Q.Core.shared;
    public class GetTasksInteractor : IInputBoundary<TaskInput>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IOutputConverter _outputConverter;
        private readonly IOutputBoundary<TaskOutput> _outputBoundary;
        public GetTasksInteractor(ITaskRepository taskRepository, IOutputBoundary<TaskOutput> outputBoundary, IOutputConverter outputConverter)
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

            TaskOutput output = _outputConverter.Map<TaskOutput>(tasks);
            _outputBoundary.Populate(output);
        }
        
    }
}
