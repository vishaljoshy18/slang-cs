using System.Reflection.Emit;
namespace SLANG
{
  // Boolean constant node , stores true or false value
  public class BooleanConstant : Expression
  {
    private Symbol _symbol;

    public BooleanConstant(bool val)
    {
      _symbol = new Symbol();
      _symbol.Name = null;
      _symbol.BooleanValue = val;
      _symbol.Type = TYPE.BOOL;
    }
    public Symbol GetSymbol() => _symbol;
    public override Symbol accept(RuntimeContext cont, Visitor v)
    {
      return v.visit(cont, this);
    }
    public override TYPE TypeCheck(CompilationContext cont) => _symbol.Type;
    public override TYPE Get_Type() => _symbol.Type;

    public override bool Compile(DNET_EXECUTABLE_GENERATION_CONTEXT dtx)
    {
      dtx.CodeOutput.Emit(OpCodes.Ldc_I4, _symbol.BooleanValue ? 1 : 0);
      return true;
    }
  }

  // Numeric constant node , stores numeric value
  public class NumericConstant : Expression
  {
    private Symbol _symbol;

    public NumericConstant(double val)
    {
      _symbol = new Symbol();
      _symbol.Name = null;
      _symbol.DoubleValue = val;
      _symbol.Type = TYPE.NUMERIC;
    }
    public Symbol GetSymbol() => _symbol;
    public override Symbol accept(RuntimeContext cont, Visitor v)
    {
      return v.visit(cont, this);
    }
    public override TYPE Get_Type() => _symbol.Type;
    public override TYPE TypeCheck(CompilationContext cont) => _symbol.Type;

    public override bool Compile(DNET_EXECUTABLE_GENERATION_CONTEXT dtx)
    {
      dtx.CodeOutput.Emit(OpCodes.Ldc_R8, _symbol.DoubleValue);
      return true;
    }
  }

  // String Literal node , stores string value
  public class StringLiteral : Expression
  {
    private Symbol _symbol;

    public StringLiteral(string val)
    {
      _symbol = new Symbol();
      _symbol.Name = null;
      _symbol.StringValue = val;
      _symbol.Type = TYPE.STRING;
    }
    public Symbol GetSymbol() => _symbol;
    public override Symbol accept(RuntimeContext cont, Visitor v)
    {
      return v.visit(cont, this);
    }
    public override TYPE Get_Type() => _symbol.Type;
    public override TYPE TypeCheck(CompilationContext cont) => _symbol.Type;

    public override bool Compile(DNET_EXECUTABLE_GENERATION_CONTEXT dtx)
    {
      dtx.CodeOutput.Emit(OpCodes.Ldstr, _symbol.StringValue);
      return true;
    }
  }
}