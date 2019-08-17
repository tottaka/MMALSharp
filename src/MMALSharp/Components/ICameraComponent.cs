﻿
using MMALSharp.Ports.Outputs;

namespace MMALSharp.Components
{
    public interface ICameraComponent : IComponent
    {
        IOutputPort PreviewPort { get; }
        IOutputPort VideoPort { get; }
        IOutputPort StillPort { get; }
        ICameraInfoComponent CameraInfo { get; }

        void Initialise();
    }
}