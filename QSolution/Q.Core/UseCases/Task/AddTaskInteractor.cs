using Q.Core.Contracts;
using Q.Core.shared;
using System;

namespace Q.Core.UseCases.Task
{
    public class AddTaskInteractor : IInputBoundary<AddTaskRequest>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IOutputConverter _outputConverter;
        private readonly IOutputBoundary<OutputResponse> _outputBoundary;

        public AddTaskInteractor(ITaskRepository taskRepository, IOutputConverter outputConverter,IOutputBoundary<OutputResponse> outputBoundary)
        {
            _taskRepository = taskRepository;
            _outputConverter = outputConverter;
            _outputBoundary = outputBoundary;
        }

        public AddTaskInteractor()
        {

        }

        public async System.Threading.Tasks.Task Process(AddTaskRequest input)
        {
            var task = _outputConverter.Map<Entities.Task>(input);
            task.CreatedBy = 1;
            task.CreatedOn = DateTime.Now;
            await _taskRepository.Add(task);
            _outputBoundary.Populate(new OutputResponse(true, null, "Successfully Added"));
        }
    }
}
