<span> <span> BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
    if (mBluetoothAdapter == null && !mBluetoothAdapter.isEnabled()) {
        Intent intent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
       startActivityForResult(intent, REQUEST_ENABLE_BT);
    }</span></span>

<span> String innerprinter_address = "00:11:22:33:44:55";
    BluetoothDevice innerprinter_device = null;
    Set</span> <span> devices = mBluetoothAdapter.getBondedDevices();
    for(BluetoothDevice device : devices){
        if(device.getAddress().equals(innerprinter_address)){
        innerprinter_device = device;
    }
     }</span>

<span>UUID PRINTER_UUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");
   BluetoothSocket mSocket =
   innerprinter_device.createRfcommSocketToServiceRecord(PRINTER_UUID);</span>

<span>  <span>OutputStream mOut = mSocket.getOutputStream();
   private void sendData(byte[] bytes) {
          if (mOut != null) {
              try {
        mOut.write(bytes, 0, bytes.length);
    mOut.flush();
              } catch (IOException e) {
        Log.e("TAG", e.getMessage());
    } finally {
                 try {
        mOut.close();
    } catch (IOException e) {}
    }
          }
    }</span></span>