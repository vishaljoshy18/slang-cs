namespace SLANG
{
  // Expression base class
  public abstract class Expression
  {
    public abstract Symbol accept(RuntimeContext cont,Visitor v);
    public abstract TYPE TypeCheck(CompilationContext cont);
    public abstract TYPE Get_Type ();
    public abstract bool Compile(DNET_EXECUTABLE_GENERATION_CONTEXT dtx);
  }
}