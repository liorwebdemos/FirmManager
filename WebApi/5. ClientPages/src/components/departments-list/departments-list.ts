import { AddWorkerModal } from "./../add-worker-modal/add-worker-modal";
import { AddDepartmentModal } from "./../add-department-modal/add-department-modal";
import { autoinject } from "aurelia-framework";
import { DepartmentModel } from "models";
import { DialogService } from "aurelia-dialog";
import { DepartmentDetailsModal } from "components/department-details-modal/department-details-modal";
import { DepartmentsService } from "services";
import { handleErrors } from "decorators";
import { DepartmentWorkersModal } from "components/department-workers-modal/department-workers-modal";

@autoinject()
export class DepartmentsList
{
  private departments: DepartmentModel[];

  constructor(
    private departmentsService: DepartmentsService,
    private dialogService: DialogService
  ) { }

  private activate(): void
  {
    this.getDepartments();
  }

  @handleErrors("An error occurred while retrieving the departments.")
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

  private openAddDepartmentModal(): void
  {
    this.dialogService.open({
      viewModel: AddDepartmentModal
    })
      .whenClosed(response =>
      {
        if (response.wasCancelled) return;
        this.departments.push(response.output);
        return this.departments.sort(DepartmentsList.sortDepartmentsByUpdatedDateDescending);
      });
  }

  private openDepartmentWorkersModal(department: DepartmentModel): void
  {
    this.dialogService.open({
      viewModel: DepartmentWorkersModal,
      model: department
    });
  }

  private openAddWorkerModal(): void
  {
    this.dialogService.open({
      viewModel: AddWorkerModal
    });
  }

  private static sortDepartmentsByUpdatedDateDescending = (a: DepartmentModel, b: DepartmentModel) =>
    (b.updatedDate?.getTime() ?? new Date().getTime()) - (a.updatedDate?.getTime() ?? new Date().getTime());
}
