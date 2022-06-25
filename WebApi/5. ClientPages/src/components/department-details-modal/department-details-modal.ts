import { autoinject } from "aurelia-framework";
import { DialogController } from "aurelia-dialog";
import { DepartmentModel } from "models/department-model";

@autoinject()
export class DepartmentDetailsModal
{
  private department: DepartmentModel;

  constructor(private dialogController: DialogController) { }

  canActivate(department: DepartmentModel): boolean
  {
    return !!department;
  }

  activate(department: DepartmentModel): void
  {
    this.department = department;
  }
}
