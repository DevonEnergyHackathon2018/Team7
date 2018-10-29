using Griedy.Lib.DataContext;

using System;
using System.Linq;

namespace Griedy.Lib.Jobs
{
    public abstract class JobBase
    {
        private readonly IDataContext _data;
        private readonly JobType _jobType;

        private JobInstance _jobInstance;

        public virtual JobInstance JobInstance
        {
            get
            {
                if (_jobInstance != null) return _jobInstance;
                throw new ApplicationException($"{_jobType.ToString()} job is not started yet.");
            }
            private set { _jobInstance = value; }
        }

        protected JobBase(IDataContext data, JobType jobType)
        {
            _data = data;
            _jobType = jobType;
        }

        public virtual bool Run()
        {
            Start();
            End("No job implementation.");
            return true;
        }

        protected virtual void Start()
        {
            var jobType = _jobType.ToString();

            /* Ensure there isn't an instance currently running. */
            if (_data.JobInstances.Any(j => j.JobTypeId == (int)_jobType && j.EndOn == null))
            {
                throw new ApplicationException($"Job type {jobType} is currently running.");
            }

            JobInstance = _data.JobInstances.Add(new JobInstance
            {
                JobStatusId = (int)JobStatus.Running,
                BeginOn = DateTime.Now,
                Message = $"{ jobType } job has started.",
                JobTypeId = (int)_jobType
            });
            _data.SaveChanges();
        }

        protected virtual void End(string message)
        {
            JobInstance.JobStatusId = (int)JobStatus.Success;
            JobInstance.EndOn = DateTime.Now;
            JobInstance.Message = message;
            _data.SaveChanges();
        }

        protected virtual void Fail(Exception ex)
        {
            JobInstance.JobStatusId = (int)JobStatus.Failure;
            JobInstance.EndOn = DateTime.Now;
            JobInstance.Message = ex.Message;
            _data.SaveChanges();
        }

        protected virtual void PartialFail(string message)
        {
            JobInstance.JobStatusId = (int)JobStatus.PartialFailure;
            JobInstance.EndOn = DateTime.Now;
            JobInstance.Message = message;
            _data.SaveChanges();
        }

        protected virtual JobDetail Info(string message)
        {
            var jobDetail = _data.JobDetails.Add(new JobDetail
            {
                JobInstanceId = JobInstance.JobInstanceId,
                Message = message,
                TimeStamp = DateTime.Now,
                Severity = Severity.Info
            });
            _data.SaveChanges();
            return jobDetail;
        }

        protected virtual JobDetail Error(string message)
        {
            var jobDetail = _data.JobDetails.Add(new JobDetail
            {
                JobInstanceId = JobInstance.JobInstanceId,
                Message = message,
                TimeStamp = DateTime.Now,
                Severity = Severity.Error
            });
            _data.SaveChanges();
            return jobDetail;
        }

        protected virtual JobDetail Warning(string message)
        {
            var jobDetail = _data.JobDetails.Add(new JobDetail
            {
                JobInstanceId = JobInstance.JobInstanceId,
                Message = message,
                TimeStamp = DateTime.Now,
                Severity = Severity.Warning
            });
            _data.SaveChanges();
            return jobDetail;
        }

        protected virtual DateTime GetLastSuccessfulRuntime()
        {
            var jobInstance = _data.JobInstances
                .Where(x => x.JobTypeId == (int)_jobType && x.JobStatusId == (int)JobStatus.Success)
                .OrderByDescending(x => x.BeginOn)
                .FirstOrDefault();

            if (jobInstance == null) { return DateTime.MinValue; }
            return jobInstance.EndOn.Value;
        }
    }
}