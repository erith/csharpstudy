import { useEffect, useState } from "react";

import "./App.css";

import { tableFromIPC, Table, RecordBatchReader } from "apache-arrow";
import { readParquet } from "parquet-wasm";
//import { ParquetReader } from "parquetjs";
console.log("test");
function App() {
  //const [count, setCount] = useState(0);

  const setup = async () => {
    //
    //const resp = await fetch("/data.parquet");
    console.log("test");
    const resp = await fetch("http://localhost:8000/test");

    const arrayBuffer = await resp.arrayBuffer();
    const uint8Array = new Uint8Array(arrayBuffer);
    //    const reader = new RecordBatchReader(uint8Array);
    //console.log(reader);
    // RecordBatchReader로부터 RecordBatch 읽기
    //reader.open();
    // let recordBatch;
    // while ((recordBatch = await reader.next())) {
    //   // recordBatch 처리
    //   console.log(recordBatch);
    // }
    const arrowUint8Array = readParquet(uint8Array);
    const arrowTable = tableFromIPC(arrowUint8Array);
    //const reader = new RecordBatchReader(arrowUint8Array);

    // const reader = arrowTable.batches[0];
    // reader.open();
    // let recordBatch;
    // while ((recordBatch = await reader.next())) {
    //   // recordBatch 처리
    //   console.log(recordBatch);
    // }

    console.log(arrowTable.batches[0].numRows);

    const nums = arrowTable.batches[0].numRows;
    for (let i = 0; i < nums; i++) {
      console.log(arrowTable.get(i).toString());
    }

    // 행 수 세기
    //let rowCount = 0;
    /*
    for await (const batch of arrowTable) {
      console.log(batch.rowCount);
      rowCount += 1;
    }
    console.log(rowCount);
    */
    /*
    

    const arrowUint8Array = readParquet(uint8Array);
    const arrowTable = tableFromIPC(arrowUint8Array);
    // const reader = new RecordBatchReader(uint8Array);
    const cursor = arrowTable.getCursor();
    let record = null;
    while ((record = await cursor.next())) {
      console.log(record);
    }
    cursor.close();
    */
    //console.log(arrowTable.getCursor());
    // // create a new cursor
    // const cursor = reader.getCursor();

    // // read all records from the file and print them
    // let record = null;
    // while ((record = await cursor.next())) {
    //   console.log(record);
    // }
    //const table = tableFromIPC(readParquet(uint8Array));
    // RecordBatchReader에서 테이블 읽기

    // const table = await Table.from(reader);

    // // 테이블의 모든 행 출력
    // await table.scan((index: number, recordBatch: any) => {
    //   const rows = recordBatch.toArray();
    //   console.log(rows); // 행 출력
    // });
  };

  useEffect(() => {
    setup();
  }, []);

  return <>zzzzz</>;
}

export default App;
