public class SavesInitCommand : ExecutableCommand
{
    private ISavesComposer _saveComposer;

    public SavesInitCommand(ISavesComposer saveComposer)
    {
        _saveComposer = saveComposer;
    }
    
    protected override void ExecuteInternal()
    {
        _saveComposer.PrepareComponents();
    }
}