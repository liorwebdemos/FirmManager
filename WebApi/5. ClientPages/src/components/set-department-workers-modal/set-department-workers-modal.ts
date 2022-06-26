import { autoinject } from "aurelia-framework";
import { DialogCancelableOperationResult, DialogController } from "aurelia-dialog";
import { DepartmentModel } from "models/department-model";
import { DepartmentsService, WorkersService } from "services";
import { handleErrors } from "decorators";
import { WorkerModel } from "models";

class UiWorkerModel
{
  data: WorkerModel;
  isChecked: boolean;

  constructor(data: WorkerModel, selectedDepartment: DepartmentModel)
  {
    this.data = data;
    this.isChecked = (this.data.departmentId === selectedDepartment.id);
  }
}

@autoinject()
export class SetDepartmentWorkersModal
{
  private selectedDepartment: DepartmentModel;
  private uiWorkers: UiWorkerModel[];

  constructor(
    private dialogController: DialogController,
    private workersService: WorkersService,
    private departmentsService: DepartmentsService
  ) { }

  private canActivate(department: DepartmentModel): boolean
  {
    return !!department;
  }

  private activate(department: DepartmentModel): Promise<UiWorkerModel[]>
  {
    // create clone (to avoid intermediate changes to the model being showed on other component before successful save)
    this.selectedDepartment = {
      ...department
    };
    return this.getUiWorkers();
  }

  // private setUiWorkerCheckValue(uiWorker: UiWorkerModel, isChecked: boolean)
  // {
  //   this.uiWorkers = this.uiWorkers.map(uw =>
  //   {
  //     if (uw.data.id === uiWorker.data.id)
  //     {
  //       uw.isChecked = isChecked;
  //     }
  //     return uw;
  //   });
  // }

  @handleErrors("An error occurred while retrieving the workers.")
  private getUiWorkers(): Promise<UiWorkerModel[]>
  {
    return this.workersService.getWorkers()
      .then(workers => this.uiWorkers = workers.map(w => new UiWorkerModel(w, this.selectedDepartment)));
  }

  @handleErrors("An error occurred while setting the department's workers.")
  private setDepartmentWorkers(): Promise<DialogCancelableOperationResult>
  {
    return this.departmentsService.setDepartmentWorkers(
      this.selectedDepartment.id,
      this.uiWorkers.filter(uw => uw.isChecked).map(uw => uw.data.id)
    )
      .then(department => this.dialogController.ok(department));
  }
}
