import { autoinject } from "aurelia-framework";
import { DialogCancelableOperationResult, DialogController, DialogService } from "aurelia-dialog";
import { DepartmentModel } from "models/department-model";
import { DepartmentsService } from "services";
import { handleErrors } from "decorators";
import { DepartmentWorkersModal } from "components/department-workers-modal/department-workers-modal";

@autoinject()
export class AddDepartmentModal
{
  private department = new DepartmentModel();

  constructor(
    private dialogController: DialogController,
    private departmentsService: DepartmentsService,
    private dialogService: DialogService
  ) { }

  @handleErrors("An error occurred while creating the new department.")
  private addDepartment(): Promise<DepartmentModel>
  {
    return this.departmentsService.addDepartment(this.department);
  }

  private addDepartmentAndClose(): Promise<DialogCancelableOperationResult>
  {
    return this.addDepartment()
      .then(department => this.dialogController.ok(department));
  }

  private addDepartmentAndOpenDepartmentWorkersModal(): void
  {
    this.addDepartment()
      .then(department => this.dialogService.open({
        viewModel: DepartmentWorkersModal,
        model: department
      })
        .whenClosed(() => this.dialogController.ok(department)));
  }
}
