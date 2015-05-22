using System;
using Projects.Contracts.Events;

namespace Projects.Domain
{
    public class ProjectAggregate : AggregateBase<ProjectState>
    {
        public ProjectAggregate(ProjectState state) : base(state ?? new ProjectState())
        {
        }

        public void Create(Guid id, string name)
        {
            if(State.Version > 0)
                throw new InvalidOperationException("Cannot recreate an existing project");
            if(string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Cannot create a new project without valid name");

            Apply(new ProjectCreated
            {
                Id = id,
                Name = name
            });
        }
    }
}