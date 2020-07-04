namespace Ncode.Grocerly.Application.Common
{
    public interface IQuery<TParam, TResult>
    {
        TResult Handle(TParam param);
    }
}
