import { autoinject, computedFrom, bindable, bindingMode } from "aurelia-framework";
import { DepartmentModel } from "models";
import { DialogService } from "aurelia-dialog";
import { DepartmentDetailsModal } from "components/department-details-modal/department-details-modal";
import { DepartmentsService } from "services";
import { handleErrors } from "decorators";
import { SetDepartmentWorkersModal } from "components/set-department-workers-modal/set-department-workers-modal";

@autoinject()
export class DepartmentsList
{
  // @bindable({ defaultBindingMode: bindingMode.toView }) private departments: DepartmentModel[];
  private departments: DepartmentModel[];

  constructor(
    private departmentsService: DepartmentsService,
    private dialogService: DialogService
  ) { }

  private activate(): void
  {
    this.getDepartments();
  }

  @handleErrors("חלה שגיאה בטעינת רשימת המחלקות")
  private getDepartments(): Promise<DepartmentModel[]>
  {
    return this.departmentsService.getDepartments()
      .then(departments => this.departments = departments.sort(DepartmentsList.sortDepartmentsByUpdatedDateDescending));
  }

  private openDepartmentDetailsModal(department: DepartmentModel): void
  {
    this.dialogService.open({
      viewModel: DepartmentDetailsModal,
      model: department
    })
      .whenClosed(response =>
      {
        if (response.wasCancelled) return;
        this.departments = this.departments
          .map(
            d => d.id === department.id
              ? response.output
              : d)
          .sort(DepartmentsList.sortDepartmentsByUpdatedDateDescending);
      });
  }

  private openSetDepartmentWorkersModal(department: DepartmentModel): void
  {
    this.dialogService.open({
      viewModel: SetDepartmentWorkersModal,
      model: department
    });
  }

  private static sortDepartmentsByUpdatedDateDescending = (a: DepartmentModel, b: DepartmentModel) =>
    (b.updatedDate?.getTime() ?? new Date().getTime()) - (a.updatedDate?.getTime() ?? new Date().getTime());
}
