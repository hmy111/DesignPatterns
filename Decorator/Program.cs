IText text = new Text();
text = new ColorDecorator(text);
text = new BlodDecorator(text);
System.Console.WriteLine(text.Content);

Console.Read();

// IComment
public interface IText
{
    public string Content { get; }
}
public class Text : IText
{
    public string Content => "text";
}

public interface IDecorator : IText
{
}
// IS IText
public abstract class DecoratorBase : IDecorator
{
    // HAS IText
    protected readonly IText _text;
    public DecoratorBase(IText text)
    {
        _text = text;
    }

    public abstract string Content { get; }
}

public class ColorDecorator : DecoratorBase
{

    public ColorDecorator(IText text) : base(text)
    {
    }

    public override string Content => $"{base._text.Content} color add red";
}

public class BlodDecorator : DecoratorBase
{
    private readonly IText text;

    public BlodDecorator(IText text) : base(text)
    {
        this.text = text;
    }

    public override string Content => $"{this.text.Content} color add blod";
}
