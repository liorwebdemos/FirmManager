import { Type } from "class-transformer";
import { TrackedModel, WorkerModel } from "models";

/**
 * 
 */
export class DepartmentModel extends TrackedModel
{
  /**  */
  public id: number;

  /**  */
  public title: string;

  /**  */
  public description: string;

  /**  */
  public isActive?: boolean;

  /**  */
  @Type(() => WorkerModel)
  public workers?: WorkerModel[];
}
