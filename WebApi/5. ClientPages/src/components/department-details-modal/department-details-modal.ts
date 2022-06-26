import { autoinject } from "aurelia-framework";
import { DialogCancelableOperationResult, DialogController, DialogService } from "aurelia-dialog";
import { DepartmentModel } from "models/department-model";
import { DepartmentsService } from "services";
import { handleErrors } from "decorators";
import { SetDepartmentWorkersModal } from "components/set-department-workers-modal/set-department-workers-modal";
// import { default as Tagify } from "@yaireo/tagify";

@autoinject()
export class DepartmentDetailsModal
{
  private selectedDepartment: DepartmentModel;

  // private tagifyInputElement: HTMLInputElement;
  // private tagifyInstance: Tagify;
  // private tagifyWhitelist: Tagify.BaseTagData[] = ["אפשרות 1", "אפשרות 2", "אפשרות 3"];

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
    // create clone (to avoid intermediate changes to the model being showed on other component before successful save)
    this.selectedDepartment = {
      ...department
      // workers: department.workers && { ...department.workers }
    };
  }

  private attached(): void
  {
    // this.tagifyInstance = new Tagify(
    //   this.tagifyInputElement,
    //   {
    //     whitelist: this.tagifyWhitelist,
    //     addTagOnBlur: false,
    //     editTags: false,
    //     enforceWhitelist: true
    //   }
    // );
  }

  @handleErrors("An error occurred while saving the department's details.")
  private updateDepartment(): Promise<DialogCancelableOperationResult>
  {
    return this.departmentsService.updateDepartment(this.selectedDepartment)
      .then(department => this.dialogController.ok(department));
  }

  private openSetDepartmentWorkersModal(): void
  {
    this.dialogService.open({
      viewModel: SetDepartmentWorkersModal,
      model: this.selectedDepartment
    });
  }

  private detached(): void
  {
    // this.tagifyInstance?.destroy();
  }
}
