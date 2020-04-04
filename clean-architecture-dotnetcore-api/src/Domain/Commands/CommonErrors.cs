using System.ComponentModel;

namespace Domain.Commands
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

    public enum CommonCustomFormatterErrors
    {
        [Description("{0} should exist")]
        EntityShouldExist
    }
}
