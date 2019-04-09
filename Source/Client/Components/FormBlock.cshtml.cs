using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace Herc.Pwa.Client.Components
{
  public class FormBlockModel<T> : BaseComponent
  {
    [Parameter] protected string Model { get; set; }
    [Parameter] protected Action<string> ModelChanged { get; set; }
    public string Label => MemberName;
    //{
    //  get
    //  {
    //    var memberExpression = Expression.Body as MemberExpression;
    //    return memberExpression.Member.Name;
    //  }
    //}

    public bool IsValid { get; set; }
    public string ValidityClass => IsValid ? "is-valid" : "is-invalid";
    [Parameter]public Expression<Func<T, object>> Expression { get; set; }
    [Parameter] public string MemberName { get; set; }
  }
}
