import { EdgeInterop, EdgeInteropName } from './Edge/Interop/EdgeInterop';
import { ClipboardInterop, ClipboardInteropName } from './Clipboard/ClipboardInterop';

function initialize() {
  console.log('Initialize Blazor-Herc');
  window[EdgeInteropName] = new EdgeInterop();
  window[ClipboardInteropName] = new ClipboardInterop();
}

initialize();