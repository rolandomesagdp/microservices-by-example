import { Coverage } from "./coverage.enum";
import { InsuranceType } from "./insurance-types.enum";
import { OfferStatus } from "./offer-status.enum";

export interface InsuranceOffer {
  id: string;
  clientId: string;
  type: InsuranceType;
  coverage: Coverage;
  expeditionDate: Date;
  expirationDate: Date;
  offerStatus: OfferStatus;
  basePrice: number;
  discount: number;
  finalPrice: number;
}
