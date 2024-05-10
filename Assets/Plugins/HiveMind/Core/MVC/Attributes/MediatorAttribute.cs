using System;

namespace HiveMind.Core.MVC.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MediatorAttribute : MVCAttribute
    {
        #region Constructor
        public MediatorAttribute(object key) : base(key) { }
        #endregion
    }
}
