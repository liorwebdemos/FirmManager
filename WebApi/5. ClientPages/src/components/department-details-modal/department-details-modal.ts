import { autoinject } from "aurelia-framework";
import { DialogCancelableOperationResult, DialogController, DialogService } from "aurelia-dialog";
import { DepartmentModel } from "models/department-model";
import { DepartmentsService } from "services";
import { handleErrors } from "decorators";
import { DepartmentWorkersModal } from "components/department-workers-modal/department-workers-modal";

@autoinject()
export class DepartmentDetailsModal
{
  private selectedDepartment: DepartmentModel;

  constructor(
    private dialogController: DialogController,
    private departmentsService: DepartmentsService,
    private dialogService: DialogService
  ) { }

  private canActivate(department: DepartmentModel): boolean
  {
    return !!department;
  }

  private activate(department: DepartmentModel): void
  {
    // create clone (to avoid intermediate changes to the model being showed on other components before successful save)
    this.selectedDepartment = {
      ...department
    };
  }

  @handleErrors("An error occurred while saving the department's details.")
  private updateDepartment(): Promise<DialogCancelableOperationResult>
  {
    return this.departmentsService.updateDepartment(this.selectedDepartment)
      .then(department => this.dialogController.ok(department));
  }

  private openDepartmentWorkersModal(): void
  {
    this.dialogService.open({
      viewModel: DepartmentWorkersModal,
      model: this.selectedDepartment
    });
  }
}
