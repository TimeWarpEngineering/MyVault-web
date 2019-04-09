import { EdgeInterop, EdgeInteropName } from './Edge/Interop/EdgeInterop';
import { ClipboardInterop, ClipboardInteropName } from './Clipboard/ClipboardInterop';

function initialize() {
  console.log('Initialize Client Javascript');
  window[EdgeInteropName] = new EdgeInterop();
  window[ClipboardInteropName] = new ClipboardInterop();
}

initialize();