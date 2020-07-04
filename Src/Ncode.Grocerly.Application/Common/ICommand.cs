namespace Ncode.Grocerly.Application.Common
{
    public interface ICommand<TParam>
    {
        void Handle(TParam parameter);
    }
}
