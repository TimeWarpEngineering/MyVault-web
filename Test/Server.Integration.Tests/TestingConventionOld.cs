//namespace Herc.Pwa.Server.Integration.Tests
//{
//  using Fixie;

//  public class TestingConvention : Discovery, Execution
//  {
//    public TestingConvention()
//    {
//      Methods.Where(aMethodExpression => aMethodExpression.Name != nameof(Setup));
//    }

//    public void Execute(TestClass aTestClass)
//    {
//      aTestClass.RunCases(aCase =>
//      {
//        object instance = aTestClass.Construct();

//        Setup(instance);

//        aCase.Execute(instance);
//      });
//    }

//    static void Setup(object aInstance)
//    {
//      System.Reflection.MethodInfo method = aInstance.GetType().GetMethod(nameof(Setup));
//      method?.Execute(aInstance);
//    }
//  }
//}
