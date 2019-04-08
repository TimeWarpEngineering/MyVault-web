import { makeEdgeUiContext } from 'edge-login-ui-web';
import { EdgeUiContextInterop } from './EdgeUiContextInterop';
import { EdgeUiContextOptions } from '../TypeDefinitions/EdgeUiContextOptions';

export const EdgeInteropName: string = 'EdgeInterop';

export class EdgeInterop {
  public EdgeUiContextInterop?: EdgeUiContextInterop;

  constructor() {
    console.log('EdgeInterop constructor');
  }

  private EdgeUiContextOptions: EdgeUiContextOptions = {
    apiKey: 'a9ef0e4134410268a37d833e49990a1b90ec79dc',
    appId: 'one.herc',
    assetsPath: './edge/index.html',
    vendorName: 'Hercules',
    vendorImageUrl: '/images/HercLogo2.svg'
  };

  InitializeEdge = async (): Promise<boolean> => {
    console.log("InitializeEdge TypeScript");
    if (!this.EdgeUiContextInterop) {
      const edgeUiContext = await makeEdgeUiContext(this.EdgeUiContextOptions);
      if (!edgeUiContext) throw "Failed to create EdgeUiContext!";
      this.EdgeUiContextInterop = new EdgeUiContextInterop(edgeUiContext);
    }
    return true;
  }
}