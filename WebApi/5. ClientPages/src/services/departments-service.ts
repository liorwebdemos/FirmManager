import { autoinject } from "aurelia-framework";
import { HttpClient } from "aurelia-fetch-client";
import environment from "../../config/environment.json";
import { DepartmentModel } from "models";
import { plainToInstance } from "class-transformer";

@autoinject()
export class DepartmentsService
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
  public getDepartments(isWithWorkers = false): Promise<DepartmentModel[]>
  {
    return this.httpClient.get(`departments?isWithWorkers=${ isWithWorkers }`)
      .then(response => response.json())
      .then((response: DepartmentModel[]) => plainToInstance(DepartmentModel, response));
  }

  public getDepartmentById(departmentId: number, isWithWorkers = false): Promise<DepartmentModel>
  {
    return this.httpClient.get(`departments/${ departmentId }?isWithWorkers=${ isWithWorkers }`)
      .then(response => response.json())
      .then((response: DepartmentModel) => plainToInstance(DepartmentModel, response));
  }

  public addDepartment(department: DepartmentModel): Promise<DepartmentModel>
  {
    return this.httpClient.post("departments", department)
      .then(response => response.json())
      .then((response: DepartmentModel) => plainToInstance(DepartmentModel, response));
  }

  public updateDepartment(department: DepartmentModel): Promise<DepartmentModel>
  {
    return this.httpClient.put("departments", JSON.stringify(department))
      .then(response => response.json())
      .then((response: DepartmentModel) => plainToInstance(DepartmentModel, response));
  }

  public deleteDepartment(departmentId: number): Promise<DepartmentModel>
  {
    return this.httpClient.delete(`departments/${ departmentId }`)
      .then(response => response.json())
      .then((response: DepartmentModel) => plainToInstance(DepartmentModel, response));
  }

  public setDepartmentWorkers(departmentId: number, workersIds: number[]): Promise<DepartmentModel>
  {
    return this.httpClient.post(`departments/${ departmentId }/workers`, JSON.stringify(workersIds))
      .then(response => response.json())
      .then((response: DepartmentModel) => plainToInstance(DepartmentModel, response));
  }
}
