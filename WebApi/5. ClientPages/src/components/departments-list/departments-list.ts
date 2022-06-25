import { autoinject, computedFrom, bindable, bindingMode } from "aurelia-framework";
import { DepartmentModel } from "models";
import { DialogService } from "aurelia-dialog";
import { DepartmentDetailsModal } from "components/department-details-modal/department-details-modal";
import { DepartmentsService } from "services";

@autoinject()
export class DepartmentsList
{
  // @bindable({ defaultBindingMode: bindingMode.toView }) private departments: DepartmentModel[];
  private departments: DepartmentModel[];

  constructor(
    private departmentsService: DepartmentsService,
    private dialogService: DialogService
  ) { }

  private activate(): Promise<DepartmentModel[]>
  {
    return this.getDepartments();
  }

  //TODO: handleErrors
  private getDepartments(): Promise<DepartmentModel[]>
  {
    return this.departmentsService.getDepartments()
      .then(departments => this.departments = departments);
  }

  private openDepartmentDetailsModal(department: DepartmentModel): void
  {
    this.dialogService.open({
      viewModel: DepartmentDetailsModal,
      model: department
    });
  }
}
