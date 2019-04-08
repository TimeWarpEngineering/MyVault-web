export const ClipboardInteropName: string = 'ClipboardInterop';

export class ClipboardInterop {

  constructor() {
    console.log('ClipboardInterop constructor');
  }

  public WriteText = async (text: string): Promise<boolean> => {
    var textArea = document.createElement("textarea");
    textArea.value = text;
    document.body.appendChild(textArea);
    textArea.select();
    document.execCommand('copy');
    document.body.removeChild(textArea);
    return true;
  }
}