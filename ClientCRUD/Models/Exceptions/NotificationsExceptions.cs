using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Models.Exceptions;
public class NotificationsExceptions : Exception
{
    public IReadOnlyList<string> Errors { get; }
    public NotificationsExceptions(IReadOnlyList<string> errors)
    {
        Errors = errors;
    }

    public override string Message => string.Join("; ", Errors);
}
