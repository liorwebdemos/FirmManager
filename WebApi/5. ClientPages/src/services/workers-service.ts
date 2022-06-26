import { autoinject } from "aurelia-framework";
import { HttpClient } from "aurelia-fetch-client";
import environment from "../../config/environment.json";
import { WorkerModel } from "models";
import { plainToInstance } from "class-transformer";

@autoinject()
export class WorkersService
{
  constructor(private httpClient: HttpClient)
  {
    httpClient.configure(config =>
    {
      config
        .useStandardConfiguration()
        .withBaseUrl(environment.apiBaseUrl);
    });
  }

  // @cache() -> do client cache
  public getWorkers(): Promise<WorkerModel[]>
  {
    return this.httpClient.get("workers")
      .then(response => response.json())
      .then((response: WorkerModel[]) => plainToInstance(WorkerModel, response));
  }

  public getWorkerById(workerId: number): Promise<WorkerModel>
  {
    return this.httpClient.get(`workers/${ workerId }`)
      .then(response => response.json())
      .then((response: WorkerModel) => plainToInstance(WorkerModel, response));
  }

  public addWorker(worker: WorkerModel): Promise<WorkerModel>
  {
    return this.httpClient.post("workers", worker)
      .then(response => response.json())
      .then((response: WorkerModel) => plainToInstance(WorkerModel, response));
  }

  public updateWorker(worker: WorkerModel): Promise<WorkerModel>
  {
    return this.httpClient.put("workers", JSON.stringify(worker))
      .then(response => response.json())
      .then((response: WorkerModel) => plainToInstance(WorkerModel, response));
  }

  public deleteWorker(workerId: number): Promise<WorkerModel>
  {
    return this.httpClient.delete(`workers/${ workerId }`)
      .then(response => response.json())
      .then((response: WorkerModel) => plainToInstance(WorkerModel, response));
  }
}
