import { DepartmentModel } from "models";
import { autoinject } from "aurelia-framework";
import { DialogCancelableOperationResult, DialogController, DialogService } from "aurelia-dialog";
import { WorkerModel } from "models/worker-model";
import { WorkersService, DepartmentsService } from "services";
import { handleErrors } from "decorators";

@autoinject()
export class AddWorkerModal
{
  private worker = new WorkerModel();
  private departments: DepartmentModel[];

  constructor(
    private dialogController: DialogController,
    private departmentsService: DepartmentsService,
    private workersService: WorkersService,
    private dialogService: DialogService
  ) { }

  @handleErrors("An error occurred while retrieving the departments.")
  private activate(): Promise<DepartmentModel[]>
  {
    return this.departmentsService.getDepartments()
      .then(departments => this.departments = departments);
  }

  @handleErrors("An error occurred while creating the new worker.")
  private addWorker(): Promise<DialogCancelableOperationResult>
  {
    return this.workersService.addWorker(this.worker)
      .then(worker => this.dialogController.ok(worker));
  }
}
