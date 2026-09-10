using System.ComponentModel.DataAnnotations;
using ContribLab.Web.Models;

namespace ContribLab.Tests;

public class ContactFormModelTests
{
    private static IList<ValidationResult> Validate(ContactFormModel model)
    {
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void Message_AcceptsNormalLengthMessage()
    {
        var model = new ContactFormModel
        {
            Name = "Jane Doe",
            Email = "jane@example.com",
            Message = "Hi, I'd like to ask a question about your product lineup."
        };

        var results = Validate(model);

        Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(ContactFormModel.Message)));
    }

    [Fact]
    public void Message_RejectsMessageLongerThanLimit()
    {
        var model = new ContactFormModel
        {
            Name = "Jane Doe",
            Email = "jane@example.com",
            Message = new string('a', 1001)
        };

        var results = Validate(model);

        Assert.Contains(results, r => r.MemberNames.Contains(nameof(ContactFormModel.Message)));
    }
}