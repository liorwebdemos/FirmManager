import { autoinject } from "aurelia-framework";
import { DialogCancelableOperationResult, DialogController, DialogService } from "aurelia-dialog";
import { WorkersService, DepartmentsService } from "services";
import { handleErrors } from "decorators";
import { DepartmentModel, WorkerModel } from "models";

@autoinject()
export class WorkerDetailsModal
{
  private selectedWorker: WorkerModel;
  private departments: DepartmentModel[];

  constructor(
    private dialogController: DialogController,
    private workersService: WorkersService,
    private departmentsService: DepartmentsService,
    private dialogService: DialogService
  ) { }

  private canActivate(worker: WorkerModel): boolean
  {
    return !!worker;
  }

  @handleErrors("An error occurred while retrieving the departments.")
  private activate(worker: WorkerModel): Promise<DepartmentModel[]>
  {
    // create clone (to avoid intermediate changes to the model being showed on other components before successful save)
    this.selectedWorker = {
      ...worker
    };

    return this.departmentsService.getDepartments()
      .then(departments => this.departments = departments);
  }

  @handleErrors("An error occurred while saving the worker's details.")
  private updateWorker(): Promise<DialogCancelableOperationResult>
  {
    return this.workersService.updateWorker(this.selectedWorker)
      .then(worker => this.dialogController.ok(worker));
  }
}
