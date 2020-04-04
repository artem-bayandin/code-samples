using System.ComponentModel;

namespace Domain.Common.Errors
{
    public enum CommonErrors
    {
        [Description("{PropertyName} should not be empty")]
        ShouldNotBeEmpty,

        [Description("{PropertyName} should be unique")]
        ShouldBeUnique,

        [Description("{PropertyName} should be greater than 0")]
        ShouldBeGreaterThan0,
    }
}
