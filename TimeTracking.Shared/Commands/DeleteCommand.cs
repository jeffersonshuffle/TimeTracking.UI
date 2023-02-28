using System;
using System.Linq.Expressions;

namespace TimeTracking.Shared.Commands
{
    public class DeleteCommand<TIdentity>: BaseCommand
    {
        public TIdentity Identity { get; set; }
       
    }
}
