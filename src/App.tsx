import { useDotNet } from './useDotNet'

function App() {

  const { dotnet, loading } = useDotNet('/dotnetapp/bin/Release/net8.0/browser-wasm/AppBundle/_framework/dotnet.js')

  const fileSelected = async (e: any) => {

    const file = e.target.files[0];
		
    const data = new Uint8Array(await file.arrayBuffer());

    const result = await dotnet.FileProcessor.ParseDxf(data)

    alert(`Result: ${result}`);
  }

  return (
    <>
      <input disabled={loading} type="file" onChange={fileSelected}></input>
    </>
  )
}

export default App
